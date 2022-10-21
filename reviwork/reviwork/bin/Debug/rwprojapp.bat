echo off
title TestOS
color 0a
cls
:x
set /p str=$ 
if %str%==info:inf goto inf
goto x
:inf
echo Created on ReviWork 1.0 in UAS
echo By codaaj(UAS creator)
goto x
