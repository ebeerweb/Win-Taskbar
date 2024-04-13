# Disable taskbar
& {
    $p = 'HKCU:SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\StuckRects3'
    $v = (Get-ItemProperty -Path $p).Settings
    $v[8] = 0x7b
    Set-ItemProperty -Path $p -Name Settings -Value $v
    Stop-Process -Force -ProcessName explorer
    echo Disabled
    Start-Sleep -Seconds 1.5
}