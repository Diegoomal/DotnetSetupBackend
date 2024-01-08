CREATE TABLE IF NOT EXISTS person (
    id serial PRIMARY KEY,
    name VARCHAR(100),
    lastname VARCHAR(100),
    birthday DATE
);