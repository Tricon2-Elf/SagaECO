-- Server-wide script variables (MapServer LoadServerVar / SaveServerVar).
-- Names must be lowercase to match MySQLActorDB SQL and Linux default (case-sensitive table names).

CREATE TABLE IF NOT EXISTS `svar` (
  `name` varchar(255) NOT NULL,
  `type` tinyint unsigned NOT NULL DEFAULT 0,
  `content` text NOT NULL,
  PRIMARY KEY (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE IF NOT EXISTS `slist` (
  `ServerVarID` varchar(36) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `key` varchar(255) DEFAULT NULL,
  `type` tinyint unsigned DEFAULT NULL,
  `content` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
