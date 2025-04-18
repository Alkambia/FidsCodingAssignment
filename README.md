### Assignment Overview:
The following document outlines a real-world problem along with its corresponding requirements. Your role in this assignment is to define and implement a comprehensive solution. We request that you utilize the C# .NET Core project template provided in this repository as a foundational starting point (Ignore the weather code it's part of the template. Change/refactor it as required), ensuring the inclusion of unit tests to validate your implementation. 

Additionally, you will find a JSON file containing the raw data required for this task. While you are encouraged to explore various aspects of this challenge, we advise against integrating any third-party libraries, with the exception of Swagger for API documentation.

Should you have any inquiries pertaining to this assignment, kindly direct them to the designated email addresses: <b>omri.r@synectmedia.com and mark.y@synectmedia.com.</b>

### Problem
ABC Airport has assigned you the task of modeling their flight information data (FIDS) and developing an API to facilitate specific data queries. 
The airport's requirement necessitates the deducing of certain normalized data based on provided rules.

### Requirements
To meet ABC Airport's specifications, the following requirements must be met:

1. Each flight must be clearly classified as either arriving or departing.

2. Capture the Flight Schedule Time, which represents the original time of a flight's intended arrival or departure.

3. Record the Flight Actual Time, representing the actual time of arrival or departure.

4. Include the Flight's Airline Code and Flight Number to uniquely identify each flight.

5. Address Flight Codeshares, where multiple flights share the same parent flight ID. The airline code and flight number should be consolidated into the main flight associated with that parent flight ID.

6. For departing flights, provide information on their destinations.

7. For arriving flights, specify their origins.

8. Determine the boarding time for departing flights. If the actual time falls within a predefined window or is earlier than the current time, the boarding time should be set to true.

9. Establish the Flight Status, marked as "boarding" if the boarding field is true, or "Closed" if the actual time exceeds a predefined threshold from the current time.

10. For departing flights, record the Gate ID.

11. Introduce an additional property to determine if a flight is currently at the gate by evaluating a predefined delta before and after the current actual time.

12. Optional: Include any other relevant fields available in the raw data.

<b>Note: Any pre-defined values should be configurable to accommodate potential adjustments in the future.</b>

### Queries
The API you develop will enable ABC Airport to perform various queries based on the generated data. These queries include:

1. Checking the status of a specific flight.

2. Identifying the currently active flight at the gate.

3. Retrieving all delayed flights based on a given delta.

### Submission
Kindly submit your solution either in the form of a compressed zip file or, preferably, by providing a link to a GitHub repository or an equivalent platform hosting your solution. Your prompt and professional response will be greatly appreciated.