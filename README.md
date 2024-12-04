# FoxESS Battery Intelligent Octopus Go Monitor
## Description
If you use Intelligent Octopus Go you sometimes get car charging slots outside of the normal six hours cheap rate charging window these are charged at the cheap rate but for some battery installations this results in the home storage battery being discharged into the car. This automation avoids this by disabling or setting the home storage battery to charge when these out of normal cheap rate slots are detected. Unlike other fixes for this problem this solution is implemented using the FoxESS cloud API calls rather than a local Modbus interface to the inverter e.g. no additional hardware and wiring required.
## How it does it
The automation allows for the setup of a default schedule to disable or charge your FoxESS home storage battery for the normal IO Go cheap rate period, outside of the period it then monitors unit cost of electricity supplied by the Octopus HACS integration if the price drop below the cheap rate it sends a call to the FoxESS API to disable of charge the home storage battery for the current thirty minute slot.
The automation uses NetDaemon V4 Home assistant addon that allows automations to be written in C# .NET 8. This addon communicates with the Home Assistant instance via a Web Hook, this allows you to test and debug the automation as a locally running application before deploying to the Home Assistant instance or any other hosting container that has network access to Home Assistant.
All entities and events on the Home Assistant instance are available just as they are when writing Python on the target instance and are accessible by their entity ID
## Prerequisites
1)	NetDaemon V4 (.NET 8) install this as an Add-On to Home Assistant
2)	A suitable development environment Visual Studio 2022 or VS Code
3)	.NET 8 SDK
4)	The Octopus Energy HACS integration or similar integration for other suppliers
## Setup
Setup is saved in the FoxBatteryControlSettings.yaml file as below:
FoxEss.FoxBatteryControlSettings:
  ApiKey: ###########-YOUR-API-KEY-##########  
  DeviceSN: #YOUR-DEVICE-SERIAL-NUMBER#
  DisablePrice: 0.075
  ChargePrice: 0.075
  CurrentRateEntityID: sensor.octopus_energy_electricity_YOUR_ACC_&_METER_NUMBER_current_rate
  OffPeakFlagEntityID: binary_sensor.octopus_energy_electricity_YOUR_ACC_&_METER_NUMBER_off_peak
  DefaultSchedule:
      Groups:
      - WorkMode: ForceCharge
        Enabled: 1
        MinSocOnGrid: 20
        FdSoc: 20
        FdPwr: 0
        StartHour: 0
        StartMinute: 0
        EndHour: 5
        EndMinute: 29
      - WorkMode: Backup
        Enabled: 1
        MinSocOnGrid: 20
        FdSoc: 20
        FdPwr: 0
        StartHour: 23
        StartMinute: 30
        EndHour: 23
        EndMinute: 59
