#!/bin/bash

# Colores para logs
GREEN='\033[0;32m'
NC='\033[0m' # Sin color

echo -e "${GREEN}1. Iniciando API .NET...${NC}"
cd WebApi || exit
dotnet run &
API_PID=$!
cd ..

sleep 5

echo -e "${GREEN}2. Levantando Docker Compose (InfluxDB + Grafana)...${NC}"
cd k6-dashboard || exit
docker compose up -d
cd ..

echo -e "${GREEN}3. Esperando que InfluxDB esté disponible...${NC}"
until curl -s http://localhost:8086/ping > /dev/null; do
  printf '.'
  sleep 1
done
echo -e "\n${GREEN}InfluxDB está listo.${NC}"

sleep 2

echo -e "${GREEN}4. Ejecutando prueba de carga con K6...${NC}"
K6_OUT=influxdb=http://localhost:8086/k6 k6 run k6-dashboard/load_test.js

echo -e "${GREEN}5. Prueba finalizada.${NC}"
echo -e "${GREEN}Dashboard en: http://localhost:3000 (admin/admin123)${NC}"

# Cleanup
echo -e "${GREEN}6. Finalizando procesos...${NC}"
kill $API_PID
