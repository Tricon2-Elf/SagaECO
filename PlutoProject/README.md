# PlutoProject

## Local MySQL (Docker)

From this directory:

```bash
docker compose up -d
```

- **Host:** `127.0.0.1` — set `dbhost` in `ConfigFiles/*.xml` if you use another host.
- **Port:** `3306` — `dbport` in config.
- **User / password:** `root` / `saga` — matches `SagaMap.xml` and `SagaLogin.xml`; adjust `SagaValidation.xml` if you use a different password there.

Databases **`sagaeco`** and **`cofeco`** are created on the **first** run (empty volume). To re-run init scripts, remove the volume:

```bash
docker compose down -v
```

Stop the server:

```bash
docker compose down
```