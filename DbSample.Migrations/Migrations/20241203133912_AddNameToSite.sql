START TRANSACTION;

ALTER TABLE "Sites" ADD "Name" text NOT NULL DEFAULT '';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241203133912_AddNameToSite', '8.0.11');

COMMIT;

