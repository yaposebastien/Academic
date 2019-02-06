#!/usr/bin/env python3.6
from __future__ import absolute_import, division, print_function
import pefile
import sys

malware_file = sys.argv[1]
pe = pefile.PE(malware_file)
for section in pe.sections:
    
    print ("Name: %s VirtualSize: %s VirtualAddr: %s  SizeofRawData: %s PointerToRawData: %s" 
        %(section.Name,  hex(section.Misc_VirtualSize), hex(section.VirtualAddress), section.SizeOfRawData, section.PointerToRawData))