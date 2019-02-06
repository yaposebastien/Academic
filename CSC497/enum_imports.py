#!/usr/bin/env python3.6
from __future__ import absolute_import, division, print_function
import pefile
import sys

malware_file = sys.argv[1]
pe = pefile.PE(malware_file)
if hasattr(pe, 'DIRECTORY_ENTRY_IMPORT'):
    for entry in pe.DIRECTORY_ENTRY_IMPORT:
        print("%s" % entry.dll)
        for imp in entry.imports:
            if imp.name != None:
                print("\t %s \t %s" % (hex(imp.address), imp.name))
            else:
                print("\tord(%s)" % (str(imp.ordinal)))
        print("\n")




