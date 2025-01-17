CREATE TABLE reservations (
    reservation_id SERIAL PRIMARY KEY,
    nom VARCHAR(50) NOT NULL,
    prenom VARCHAR(50),
    carte_numero BIGINT CHECK (carte_numero::TEXT ~ '^\d{16}$'), -- Limitation à 16 chiffres sans restriction de valeur
    carte_cvv SMALLINT CHECK (carte_cvv BETWEEN 100 AND 999), -- Vérification de format
    carte_date_expiration VARCHAR(10) CHECK (carte_date_expiration ~ '^(0[1-9]|1[0-2])/\d{2,4}$'), -- Format MM/YY ou MM/YYYY
    email VARCHAR(100) UNIQUE, -- Ajout d'unicité pour éviter les doublons
    telephone VARCHAR(15) NOT NULL CHECK (telephone ~ '^\+?[0-9]{7,15}$'), -- Format de numéro de téléphone
    date_arrivee DATE NOT NULL,
    date_depart DATE NOT NULL CHECK (date_depart > date_arrivee), -- Logique métier
    chambre_id INTEGER NOT NULL REFERENCES chambres(chambre_id) ON DELETE CASCADE,
    petit_dejeuner_quantite NUMERIC(5, 2) CHECK (petit_dejeuner_quantite >= 0), -- Taille ajustée pour la précision
    nombre_personnes SMALLINT NOT NULL CHECK (nombre_personnes > 0),
    tarif_base NUMERIC(10, 2) DEFAULT (
        SELECT tarif FROM chambres WHERE chambres.chambre_id = chambre_id
    ),
    tarif_final NUMERIC(10, 2),
    statut_arrive BOOLEAN DEFAULT FALSE,
    statut_depart BOOLEAN DEFAULT FALSE,
    date_creation TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    date_modification TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    numero_reservation VARCHAR(20) UNIQUE NOT NULL,
    commentaires TEXT
);

-- Création de la fonction de mise à jour de tarif_final
CREATE OR REPLACE FUNCTION update_tarif_final()
RETURNS TRIGGER AS $$
BEGIN
    NEW.tarif_final := (NEW.nombre_personnes * (SELECT tarif_taxe FROM taxes LIMIT 1)) + 
                        (NEW.tarif_base * (NEW.date_depart - NEW.date_arrivee));
RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Ajout du trigger à la table reservations
CREATE TRIGGER trigger_update_tarif_final
    BEFORE INSERT OR UPDATE ON reservations
                         FOR EACH ROW
                         EXECUTE FUNCTION update_tarif_final();

-- Table tarifs_nuit
CREATE TABLE tarifs_nuit (
                             tarif_id SERIAL PRIMARY KEY,
                             nom VARCHAR(50) NOT NULL UNIQUE,
                             prix NUMERIC(10, 2) NOT NULL CHECK (prix >= 0),
                             commentaires TEXT
);

-- Table taxes
CREATE TABLE taxes (
                       taxe_id SERIAL PRIMARY KEY,
                       nom VARCHAR(50) NOT NULL UNIQUE,
                       tarif_taxe NUMERIC(10, 2) NOT NULL CHECK (tarif_taxe >= 0),
                       commentaires TEXT
);

-- Table chambres
CREATE TABLE chambres (
                          chambre_id SERIAL PRIMARY KEY,
                          type_id INTEGER NOT NULL REFERENCES types_chambres(type_id) ON DELETE CASCADE,
                          tarif NUMERIC(10, 2) GENERATED ALWAYS AS (
                              (SELECT tarif FROM types_chambres WHERE types_chambres.type_id = chambres.type_id)
                              ) STORED,
                          nombre_lits_simples SMALLINT GENERATED ALWAYS AS (
                              (SELECT nombre_lits_simples FROM types_chambres WHERE types_chambres.type_id = chambres.type_id)
                              ) STORED,
                          nombre_lits_doubles SMALLINT GENERATED ALWAYS AS (
                              (SELECT nombre_lits_doubles FROM types_chambres WHERE types_chambres.type_id = chambres.type_id)
                              ) STORED,
                          capacite SMALLINT GENERATED ALWAYS AS (
                              (SELECT capacite FROM types_chambres WHERE types_chambres.type_id = chambres.type_id)
                              ) STORED,
                          usable BOOLEAN NOT NULL DEFAULT TRUE, -- Ajout de la colonne usable avec correction
                          commentaires TEXT
);

-- Table types_chambres
CREATE TABLE types_chambres (
                                type_id SERIAL PRIMARY KEY,
                                nom VARCHAR(50) NOT NULL UNIQUE,
                                tarif NUMERIC(10, 2) NOT NULL CHECK (tarif >= 0),
                                nombre_lits_simples SMALLINT NOT NULL CHECK (nombre_lits_simples >= 0),
                                nombre_lits_doubles SMALLINT NOT NULL CHECK (nombre_lits_doubles >= 0),
                                capacite SMALLINT NOT NULL CHECK (capacite > 0),
                                commentaires TEXT
);

-- Table hotels
CREATE TABLE hotels (
                        hotel_id SERIAL PRIMARY KEY,
                        nom VARCHAR(50) NOT NULL UNIQUE,
                        adresse VARCHAR(100) NOT NULL UNIQUE,
                        telephone VARCHAR(15) NOT NULL UNIQUE CHECK (telephone ~ '^\+?[0-9]{7,15}$'),
    email VARCHAR(100) NOT NULL UNIQUE,
    commentaires TEXT
);

-- Index pour optimiser les recherches
CREATE INDEX idx_reservations_chambre_id ON reservations(chambre_id);
CREATE INDEX idx_reservations_date_arrivee ON reservations(date_arrivee);
CREATE INDEX idx_reservations_date_depart ON reservations(date_depart);
CREATE INDEX idx_chambres_type_id ON chambres(type_id);
