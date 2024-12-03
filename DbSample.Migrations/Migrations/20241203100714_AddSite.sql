START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241203100714_AddSite') THEN
    ALTER TABLE "Participants" ADD "SiteId" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241203100714_AddSite') THEN
    CREATE TABLE "Site" (
        "Id" uuid NOT NULL,
        "ProjectId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_Site" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Site_Projects_ProjectId" FOREIGN KEY ("ProjectId") REFERENCES "Projects" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241203100714_AddSite') THEN
    CREATE INDEX "IX_Participants_SiteId" ON "Participants" ("SiteId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241203100714_AddSite') THEN
    CREATE INDEX "IX_Site_ProjectId" ON "Site" ("ProjectId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241203100714_AddSite') THEN
    ALTER TABLE "Participants" ADD CONSTRAINT "FK_Participants_Site_SiteId" FOREIGN KEY ("SiteId") REFERENCES "Site" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20241203100714_AddSite') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20241203100714_AddSite', '8.0.11');
    END IF;
END $EF$;
COMMIT;

