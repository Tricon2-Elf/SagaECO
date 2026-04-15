-- Runs once on first container startup (empty data volume).
-- Aligns with ConfigFiles: sagaeco (login/map), cofeco (validation sample).

CREATE DATABASE IF NOT EXISTS sagaeco CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
CREATE DATABASE IF NOT EXISTS cofeco CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
