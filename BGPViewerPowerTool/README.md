# Windows, Mac or Linux User (Powershell Solution)
If you're a normal human (maybe not so normal cause you probably work with telecom :laughing::sweat_smile:) and likes Powershell, then you can use [BGPViewerPowerTool](https://github.com/wallacemariadeandrade/BGPViewerTool/tree/development/BGPViewerPowerTool)! It's a bunch of PowerShell scripts that do all the work for you. Download the folder and call the scripts from PowerShell prompt at scripts directory.

> [PowerShell](https://docs.microsoft.com/pt-br/powershell/scripting/overview?view=powershell-7) is a cross-platform task automation and configuration management framework, consisting of a command-line shell and scripting language. Unlike most shells, which accept and return text, PowerShell is built on top of the .NET Common Language Runtime (CLR), and accepts and returns .NET objects. This fundamental change brings entirely new tools and methods for automation.

Download PowerShell [here](https://docs.microsoft.com/pt-br/powershell/scripting/install/installing-powershell?view=powershell-7).

## Permit Powershell to Excute Scripts
By default PowerShell doesn't allow scripts execution. To turn it on you have to run PowerShell as Administrator and paste the command bellow:
```
set-executionpolicy remotesigned

```
## Examples
- Get ASN Details: 
    - ```.\get_asn_details.ps1 3356 ```
- Get ASN Prefixes:
    - ```.\get_asn_prefixes.ps1 3356 ```
- Get ASN Peers:
    - ```.\get_asn_peers.ps1 3356 ```
- Get ASN Upstreams:
    - ```.\get_asn_upstreams.ps1 3356 ```
- Get ASN Downstreams:
    - ```.\get_asn_downstreams.ps1 3356 ```
- Get ASN IXs:
    - ```.\get_asn_ixs.ps1 3356 ```
- Get Prefix Details:
    - ```.\get_prefix_details.ps1 4.55.0.0/16 or .\get_prefix_details.ps1 4.55.0.0 16 ```
- Get IP Address Details:
    - ```.\get_ip_details.ps1 4.55.0.0 ```
- Search by ASN, Prefix, IP Address, Name
    - ```.\search.ps1 "Century Link" or .\search.ps1 CenturyLink or .\search.ps1 3356 ```
