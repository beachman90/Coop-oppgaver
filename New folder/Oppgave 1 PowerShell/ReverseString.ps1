# Definer stien til filen
$filePath = "C:\Users\jistr\source\repos\Coop oppgaver\New folder\Oppgave 1 PowerShell\Oppgave 1\file.txt"

# Sjekk om filen eksisterer
if (Test-Path $filePath) {
    # Les hver linje i filen
    $linjer = Get-Content -Path $filePath

    # Behandle hver linje
    foreach ($linje in $linjer) {
        # Konverter linjen til en char-array
        $charArray = $linje.ToCharArray()
        # Omvend char-arrayet
        [array]::Reverse($charArray)
        # Sett sammen char-arrayet tilbake til en streng
        $omvendtLinje = -join $charArray

        # Skriv ut den omvendte linjen
        Write-Output $omvendtLinje
    }
} else {
    Write-Output "Filen ble ikke funnet på angitt sted: $filePath"
}
