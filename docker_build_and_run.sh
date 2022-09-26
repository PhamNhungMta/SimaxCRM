docker build -f Dockerfile -t simaxcrm-contained .
docker-compose down
docker-compose -f docker-compose.yml up -d