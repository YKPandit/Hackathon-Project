PROJECT_DIR := C:\Users\Yaaska Pandit\RiderProjects\Hackathon-Project\New_AWS_Project


FRAMEWORK := net8.0

.PHONY: clean
clean:
    
    dotnet clean $(PROJECT_DIR)

.PHONY: build
build:
    
    dotnet build $(PROJECT_DIR) -f $(FRAMEWORK)


.PHONY: run
run:
    
    dotnet run --project $(PROJECT_DIR) -f $(FRAMEWORK)

.PHONY: all
all: clean build run

#Run: all
