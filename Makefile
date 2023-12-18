up:
	@echo "Starting Docker images..."
	docker-compose up -d
	@echo "Docker images started!"

up_build:
	@echo "Stopping running docker images..."
	docker-compose down
	@echo "Building and starting docker images..."
	docker-compose up --build -d 
	@echo "Docker images built and started!"

down:
	@echo "Stopping docker compose..."
	docker-compose down
	@echo "Done!"