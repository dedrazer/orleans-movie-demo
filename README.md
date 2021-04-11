# Movies Microservice
**Version: 1.0**

## Usage

After running the application it will be available on localhost in the port specified in the console toolbar.
All methods are available inside the Movie Grain (URL: http://localhost:6600/api/movie/).

### Methods

- **GetTop**
  - List top N highest rated movies
- **All**
  - List all movies
- **Get**
  - Select a movie by ID
- **Create**
  - Create a new movie that can be retrieved in the movies list
- **Update**
  - Update movies data. Empty fields will not be considered.

### Unit Tests

All methods are tested in the Movies.Test Project