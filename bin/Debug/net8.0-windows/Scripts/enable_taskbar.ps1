# Enable taskbar
& {
    $p = 'HKCU:SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\StuckRects3'
    $v = (Get-ItemProperty -Path $p).Settings
    $v[8] = 0x7a
    Set-ItemProperty -Path $p -Name Settings -Value $v
    Stop-Process -Force -ProcessName explorer
}