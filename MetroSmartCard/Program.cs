// Metro Smart Card System
// Description
// Scenario-Based Coding Problem: Metro Smart Card System

// Problem Statement

// You are tasked with implementing a metro smart card system for a city's public transportation network. The system manages commuters' travel cards, tracks their journeys, calculates fares based on distance traveled, and provides travel history and analytics. The system is managed by the MetroCardManager class.

// Real-World Scenario

// In a modern metro system, commuters use smart cards to tap in and out at stations. The fare is calculated based on the distance between entry and exit stations. The system needs to track journeys, prevent fare evasion, and provide commuters with their travel history and spending patterns.

// Classes Structure

// Provided Classes (Do Not Modify)

 

// // Do not modify

// class TravelSummary {

//     long lastEntryStation;

//     long lastExitStation;

//     long lastEntryTime;

//     long lastExitTime;

//     double totalFarePaid;

//     int totalTrips;

//     double averageFarePerTrip;

// }

 

// // Do not modify

// class Commuter {

//     int cardNumber;

//     String commuterName;

//     String commuterType; // "SENIOR", "ADULT", "STUDENT", "CHILD"

//     TravelSummary travelSummary;

// }

 

// // Do not modify

// class Station {

//     int stationId;

//     String stationName;

//     int zone; // 1, 2, or 3 (different fare zones)

//     double latitude;

//     double longitude;

// }

 

// // Do not modify

// interface MetroOperations {

//     void issueCard(int cardNumber, String commuterName, String commuterType);

//     bool tapIn(int cardNumber, int stationId, long epochTime);

//     bool tapOut(int cardNumber, int stationId, long epochTime);

//     Commuter getCommuterInfo(int cardNumber);

//     List<Double> fareHistory(int cardNumber);

//     Dictionary<String, Double> getZoneWiseRevenue(long startTime, long endTime);

//     List<String> getFrequentRoute(int cardNumber);

//     double getDailyPassSavings(int cardNumber, long date);

// }

// Requirements

// Implement the MetroCardManager class that implements the MetroOperations interface with the following specifications:

// 1. MetroCardManager(List<Station> stations, double baseFare, double perKmRate, double maxDailyCap)

// ·        Constructor that initializes the metro system

// ·        stations: List of all stations in the network with their details

// ·        baseFare: Minimum fare for any journey (in rupees/cents)

// ·        perKmRate: Additional fare per kilometer traveled

// ·        maxDailyCap: Maximum fare a commuter pays in a single day

// 2. void issueCard(int cardNumber, String commuterName, String commuterType)

// ·        Issues a new metro card to a commuter

// ·        Each card number must be unique

// ·        Initialize travel summary with default values

// ·        Apply discounts based on commuter type:

// o   "SENIOR": 50% discount on all fares

// o   "STUDENT": 25% discount on all fares

// o   "CHILD": 75% discount on all fares

// o   "ADULT": No discount

// 3. boolean tapIn(int cardNumber, int stationId, long epochTime)

// ·        Records a commuter entering a station

// ·        Returns true if:

// o   Card exists and is valid

// o   Commuter is not already tapped in (no active journey)

// o   Station exists in the system

// ·        Returns false otherwise

// ·        Updates the commuter's lastEntryStation and lastEntryTime

// ·        Journey starts tracking

// 4. boolean tapOut(int cardNumber, int stationId, long epochTime)

// ·        Records a commuter exiting a station

// ·        Returns `true`` if:

// o   Card exists

// o   Commuter has an active journey (tapped in)

// o   Exit station exists

// o   Exit time is after entry time

// o   Entry and exit stations are different

// ·        Returns false otherwise

// ·        Calculates fare based on:

// text

// distance = calculateDistance(entryStation, exitStation) // in kilometers

// duration = (exitTime - entryTime) / (1000 * 60) // in minutes

 

// if duration > 120: // Journey took more than 2 hours

//     fare = baseFare * 3 // Penalty for extremely long journey

 

// else:

//     fare = baseFare + (distance * perKmRate)

 

// apply commuter type discount

// apply daily cap (if total fares today >= maxDailyCap, today's remaining journeys are free)

// ·        Updates commuter's travel summary:

// o   Updates lastExitStation and lastExitTime

// o   Adds fare to totalFarePaid

// o   Increments totalTrips

// o   Updates averageFarePerTrip

// ·        Ends the journey

// 5. Commuter getCommuterInfo(int cardNumber)

// ·        Returns the Commuter object with all details including:

// o   Card number, name, type

// o   Travel summary with last entry/exit stations and times

// o   Total fare paid, total trips, average fare

// 6. List<Double> fareHistory(int cardNumber)

// ·        Returns the last 5 fares paid by the commuter

// ·        Sorted in descending order (highest fare first)

// ·        If fewer than 5 fares exist, return all available

// ·        If no fares exist, return empty list

// 7. Map<String, Double> getZoneWiseRevenue(long startTime, long endTime)

// ·        Returns revenue grouped by zone combinations

// ·        Key format: "ZoneX-ZoneY" (e.g., "Zone1-Zone2")

// ·        Value: Total revenue from journeys between these zones in the time period

// ·        Only include zone pairs with revenue > 0

// ·        Sort by revenue descending

// 8. List<String> getFrequentRoute(int cardNumber)

// ·        Returns the top 3 most frequent routes for the commuter

// ·        Format: "StationName1 to StationName2"

// ·        Sorted by frequency (most frequent first)

// ·        If fewer than 3 routes exist, return all available

// ·        If no routes exist, return empty list

// 9. double getDailyPassSavings(int cardNumber, long date)

// ·        Calculate how much money the commuter saved if they had bought a daily pass

// ·        Daily pass cost = maxDailyCap × 0.8 (20% discount for buying pass)

// ·        Savings = (actual fares paid on that day) - (daily pass cost)

// ·        If savings is negative, return 0 (no savings)

// ·        If no journeys on that day, return 0

// Constraints

// ·        1 ≤ numberOfRequests ≤ 10^5

// ·        1 ≤ stations ≤ 200

// ·        1 ≤ baseFare ≤ 50

// ·        0.1 ≤ perKmRate ≤ 5.0

// ·        100 ≤ maxDailyCap ≤ 1000

// ·        1 ≤ cardNumber ≤ 10^9

// ·        1 ≤ stationId ≤ 1000

// ·        0 ≤ epochTime ≤ 10^18

// ·        Distance between stations: 1 to 50 km

// Distance Calculation Formula

// java

// private double calculateDistance(Station s1, Station s2) {

//     double lat1 = Math.toRadians(s1.latitude);

//     double lon1 = Math.toRadians(s1.longitude);

//     double lat2 = Math.toRadians(s2.latitude);

//     double lon2 = Math.toRadians(s2.longitude);

   

//     double dlat = lat2 - lat1;

//     double dlon = lon2 - lon1;

   

//     double a = Math.pow(Math.sin(dlat/2), 2) +

//                Math.cos(lat1) * Math.cos(lat2) *

//                Math.pow(Math.sin(dlon/2), 2);

   

//     double c = 2 * Math.asin(Math.sqrt(a));

//     double r = 6371; // Earth's radius in kilometers

   

//     return r * c;

// }

// Input Format

// First line: numberOfRequests baseFare perKmRate maxDailyCap
// Second line: numberOfStations
// Next numberOfStations lines: stationId stationName zone latitude longitude
// Followed by numberOfRequests lines of commands.

// Commands:

// 1.     issueCard cardNumber commuterName commuterType

// o   Issue a new card

// 2.     tapIn cardNumber stationId epochTime

// o   Tap in at station

// 3.     tapOut cardNumber stationId epochTime

// o   Tap out at station

// 4.     commuterInfo cardNumber

// o   Get commuter information

// 5.     fareHistory cardNumber

// o   Get fare history

// 6.     zoneRevenue startTime endTime

// o   Get zone-wise revenue

// 7.     frequentRoute cardNumber

// o   Get frequent routes

// 8.     dailySavings cardNumber date

// o   Get daily pass savings (date in YYYYMMDD format)

// Output Format

// For each command, output:

// ·        issueCard: No output

// ·        tapIn: Print true or false on new line

// ·        tapOut: Print true or false on new line

// ·        commuterInfo: Print in format: cardNumber commuterName commuterType lastEntryStation lastExitStation lastEntryTime lastExitTime totalFarePaid totalTrips averageFarePerTrip

// ·        fareHistory: Print each fare on new line, descending order

// ·        zoneRevenue: Print each zone pair and revenue as ZoneX-ZoneY:revenue on new lines, sorted by revenue descending

// ·        frequentRoute: Print each route on new line as StationName1 to StationName2

// ·        dailySavings: Print a single number (savings amount)

// Sample Input

// text

// 15 20 2.5 200

// 3

// 1 Central 1 28.6139 77.2090

// 2 North 1 28.7041 77.1025

// 3 South 2 28.4595 77.0266

// issueCard 1001 "John Doe" ADULT

// issueCard 1002 "Jane Smith" SENIOR

// tapIn 1001 1 1000

// tapIn 1002 2 1500

// tapOut 1001 2 3600000

// tapOut 1002 3 5400000

// tapIn 1001 1 7200000

// tapOut 1001 3 10800000

// commuterInfo 1001

// fareHistory 1001

// zoneRevenue 0 86400000

// frequentRoute 1001

// dailySavings 1001 20240315

// Sample Output

// text

// true

// true

// true

// true

// true

// true

// 1001 John Doe ADULT 1 3 7200000 10800000 185.5 2 92.75

// 102.5

// 83.0

// Zone1-Zone2:102.5

// Zone1-Zone3:83.0

// Central to North

// Central to South

// 15.5

// Explanation

// 1.     issueCard: Two cards issued - Adult and Senior

// 2.     tapIn 1001 1 1000: John taps in at Central station

// 3.     tapIn 1002 2 1500: Jane taps in at North station

// 4.     tapOut 1001 2 3600000: John travels Central to North (1 hour)

// o   Distance ≈ 10 km

// o   Fare = 20 + (10 × 2.5) = 45

// o   No discount (ADULT)

// 5.     tapOut 1002 3 5400000: Jane travels North to South (1.5 hours)

// o   Distance ≈ 28 km

// o   Fare = 20 + (28 × 2.5) = 90

// o   Senior discount (50%) = 45

// 6.     tapIn 1001 1 7200000: John taps in again at Central

// 7.     tapOut 1001 3 10800000: John travels Central to South (1 hour)

// o   Distance ≈ 25 km

// o   Fare = 20 + (25 × 2.5) = 82.5

// o   Total day fare = 45 + 82.5 = 127.5 (under daily cap of 200)

// 8.     commuterInfo 1001: Shows John's details and travel summary

// 9.     fareHistory 1001: Returns [102.5, 83.0] - but wait, correction: actual fares were 45 and 82.5, but output shows 102.5 and 83.0 - this suggests sample output might have different distance calculations

// 10.  zoneRevenue: Revenue from Zone1-Zone2 (Central to North) and Zone1-Zone3 (Central to South)

// 11.  frequentRoute: John's most frequent routes

// 12.  dailySavings: Daily pass cost = 200 × 0.8 = 160, Actual spent = 127.5, Savings = 0 (since actual < pass cost)

// Edge Cases to Consider

// 1.     Invalid tap-outs: Tapping out at same station as entry should return false (no travel)

// 2.     Forgotten tap-outs: If a commuter doesn't tap out, next tap-in should be rejected until previous journey is resolved

// 3.     Late night travel: Journeys crossing midnight should still be counted in the start date for daily cap

// 4.     Station transfers: Commuters can change trains, but still count as one journey if within time limit

// 5.     System failures: Handle cases where tap-in/out records might be missing

// 6.     Peak hours: Could extend to have different rates for peak/off-peak hours

// Evaluation Criteria

// Your solution will be evaluated on:

// 1.     Correctness (35%): All operations produce expected results

// 2.     Efficiency (30%): Handle up to 10^5 requests efficiently

// 3.     Edge Cases (20%): Handle invalid inputs, boundary conditions, and real-world scenarios

// 4.     Design (15%): Clean, maintainable code with proper error handling

// Hints

// ·        Use HashMap<Integer, Commuter> for card management

// ·        Use HashMap<Integer, Station> for quick station lookup

// ·        Track active journeys with HashMap<Integer, Journey> storing entry details

// ·        For fare history, maintain a Deque<Double> per commuter (limited to last 5)

// ·        For zone revenue, use HashMap<String, Double> with zone pair keys

// ·        For frequent routes, use HashMap<String, Integer> to count route frequencies

// ·        Daily cap tracking requires maintaining daily totals using HashMap<Integer, HashMap<Long, Double>> (card → date → total fare)

// ·        Time complexity target: O(1) for most operations, O(n log n) for reports

// This scenario-based problem tests:

// ·        Real-world system design thinking

// ·        Handling of complex business rules (discounts, caps, penalties)

// ·        Data structure selection for performance

// ·        Edge case handling in transportation systems

// ·        Report generation from transaction data

class Program
{
    public static void Main(string[] args)
    {
        // Sample usage of MetroCardManager can be implemented here for testing
        // For example, initializing stations, creating a MetroCardManager instance, and processing commands
    }
}