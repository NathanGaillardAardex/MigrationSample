START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241203103942_FixedSite') THEN
    ALTER TABLE "Participants" DROP CONSTRAINT "FK_Participants_Site_SiteId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241203103942_FixedSite') THEN
    ALTER TABLE "Site" DROP CONSTRAINT "FK_Site_Projects_ProjectId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241203103942_FixedSite') THEN
    ALTER TABLE "Site" DROP CONSTRAINT "PK_Site";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241203103942_FixedSite') THEN
    ALTER TABLE "Site" RENAME TO "Sites";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241203103942_FixedSite') THEN
    ALTER INDEX "IX_Site_ProjectId" RENAME TO "IX_Sites_ProjectId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241203103942_FixedSite') THEN
    ALTER TABLE "Sites" ADD CONSTRAINT "PK_Sites" PRIMARY KEY ("Id");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241203103942_FixedSite') THEN
    ALTER TABLE "Participants" ADD CONSTRAINT "FK_Participants_Sites_SiteId" FOREIGN KEY ("SiteId") REFERENCES "Sites" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241203103942_FixedSite') THEN
    ALTER TABLE "Sites" ADD CONSTRAINT "FK_Sites_Projects_ProjectId" FOREIGN KEY ("ProjectId") REFERENCES "Projects" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241203103942_FixedSite') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20241203103942_FixedSite', '8.0.11');
    END IF;
END $EF$;
COMMIT;

