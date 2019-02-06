#!/usr/bin/env python3.6
from __future__ import absolute_import, division, print_function
import pefile
import sys

malware_file = sys.argv[1]
pe = pefile.PE(malware_file)

if hasattr(pe, 'DIRECTORY_ENTRY_EXPORT'):
    for exp in pe.DIRECTORY_ENTRY_EXPORT.symbols:
        print("%s \t %s \t %s"  % (hex(exp.address + pe.OPTIONAL_HEADER.ImageBase), exp.name, exp.ordinal))
