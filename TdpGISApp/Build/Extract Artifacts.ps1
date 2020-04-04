$SourceFolder = "$(build.artifactstagingdirectory)"

$files = Get-ChildItem $SourceFolder -Recurse -Include  *.zip | where {! $_.PSIsContainer}

foreach ($file in $files) {    
     
    Write-Host "Current the zip file:  $($file.FullName)" 
    
    $CurrentPath = "$(Build.SourcesDirectory)/TdpGISApp/Output/$($file.BaseName)"
    
     Remove-Item $CurrentPath -Force  -Recurse -ErrorAction SilentlyContinue
     
     New-Item -Path "$(Build.SourcesDirectory)/TdpGISApp/Output" -Name "$($file.BaseName)" -ItemType "directory"

     Write-Host "Current Destination of zip file:  $($CurrentPath)" 
    
     Expand-Archive -LiteralPath $file.FullName -DestinationPath   $CurrentPath
}
