PROJECT_DIR := .


FRAMEWORK := net8.0

.PHONY: clean
clean:
    @echo "Cleaning the project..."
    dotnet clean $(PROJECT_DIR)

.PHONY: build
build:
    @echo "Building the project..."
    dotnet build $(PROJECT_DIR) -f $(FRAMEWORK)


.PHONY: run
run:
    @echo "Running the project..."
    dotnet run --project $(PROJECT_DIR) -f $(FRAMEWORK)

.PHONY: all
all: clean build run

#Run: all
