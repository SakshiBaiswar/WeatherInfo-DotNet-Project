# WeatherInfo-DotNet-Project
### *Key functionality*: 
```
1. Display of current weather information of the required city.
2.The command Line Tool calls the following end point to fetch the related information:
https://api.open-meteo.com/v1/forecast?latitude=18.9667&longitude=72.8333&cur
rent_weather=true 
3.Longitude and Latitude for the Cities have been stored in local data file.
4.Data Invalid and not available checks have been added.
```
**************************************

### *Running the code*:

```
1. Download the repository.
2. Open the folder to find the required files.
3. Open the Weather_Info.csproj file in Visual Studio.
4. Once the file is open, run it by Ctrl + F5.
5. Compiler Window should open, with the statement written : "Enter City :"
6. Give input of the city of your choice and press enter. ( The Name of cities differ as per the local data that has been extracted from 
"https://simplemaps.com/data/in-cities", for eg :- Kolkata has been given as 'Kolkāta', so for some cities naming conventions, location.json file can be opened and checked)
7. If the city name is valid , weather data will be displayed in the belowline.
8.If City name is not Present , error message of "City not valid." will be displayed.
9.If weather data for entered city is not present , error message of "Current weather information unavailable." will be displayed.
```
***************************************
### *Authors*:

- **Sakshi Baiswar** *Initial Work* [SakshiBaiswar](https://github.com/SakshiBaiswar)

***************************************
