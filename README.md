# Unit Converter Web Application

A simple web application that converts between different units of measurement including length, weight, and temperature.

## Features

- **Length Converter**: Convert between millimeter, centimeter, meter, kilometer, inch, foot, yard, and mile
- **Weight Converter**: Convert between milligram, gram, kilogram, ounce, and pound
- **Temperature Converter**: Convert between Celsius, Fahrenheit, and Kelvin

## Installation

1. Make sure you have Python 3.7+ installed on your system

2. Install the required dependencies:
```bash
pip install -r requirements.txt
```

## Running the Application

1. Navigate to the project directory:
```bash
cd /Users/mac/UnitConverter
```

2. Run the Flask application:
```bash
python app.py
```

3. Open your web browser and go to:
```
http://127.0.0.1:5000
```

## Usage

1. From the home page, select the type of conversion you want to perform (Length, Weight, or Temperature)
2. Enter the value you want to convert
3. Select the unit to convert from
4. Select the unit to convert to
5. Click the "Convert" button
6. The converted value will be displayed on the same page

## Project Structure

```
UnitConverter/
├── app.py              # Main Flask application with conversion logic
├── requirements.txt    # Python dependencies
├── static/
│   └── style.css      # Stylesheet for the web pages
└── templates/
    ├── index.html     # Home page
    ├── length.html    # Length conversion page
    ├── weight.html    # Weight conversion page
    └── temperature.html # Temperature conversion page
```

## Technologies Used

- **Backend**: Python, Flask
- **Frontend**: HTML5, CSS3
- **No database required** - All calculations are done server-side
# UnitConverter
