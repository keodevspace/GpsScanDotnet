# GpsScanDotnet

GpsScanDotnet is a simple web application that captures the user's geolocation and saves it to a file on the backend.

## Features
- Captures the user's latitude, longitude, and timestamp using the browser's geolocation API.
- Sends the location data to a backend API.
- Saves the location data to a `location.txt` file on the server.

## How It Works
1. The user clicks a button on the frontend (`index.html`).
2. The browser captures the user's geolocation using `navigator.geolocation`.
3. The location data is sent to the backend API (`/api/location`).
4. The backend saves the location data to `location.txt`.

## Requirements
- .NET 6.0 or later
- A modern web browser with geolocation support

## How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/GpsScanDotnet.git
   cd GpsScanDotnet/GpsScanDotnet.App
2. Run the backend:
3. Open the index.html file in your browser.
4. Click the "Send Location" button to capture and send your location.
5. If you want, customize the repository URL and license information as needed.

## Notes
- The backend must be running on http://localhost:5000 for the frontend to work.
- Ensure that the browser has permission to access the user's location.

## License
This project is licensed under the MIT License. See the LICENSE file for details.