# rebrand
A (quick) tagging utility

## Summary & Usage
Essentially a utility/ tool to quickly tag specific filetypes.

Usage:
- Local operations:
	- `rebrand -<filetype> -lf <tagname>`: append the tag to the front of each file (if it matches filetype)
	- `rebrand -<filetype> -lb <tagname>`: append the tag to the end of each file (if it matches filetype)
- Global operations:
	- `rebrand -<filetype> -f<path> <tagname>`: append the tag to the front of each file (if it matches filetype) in the given directory 
	- `rebrand -<filetype> -b<path> <tagname>`: append the tag to the back of each file (if it matches filetype) in the given directory
- `rebrand -h`: Show a similar helptext

Examples:

- `rebrand -sprx -lf PS3`: Append the tag _"PS3"_ to the front of each file in the current directory which has the `.sprx` extension. 
- `rebrand -smali -bC:\AndroidApplicationRE Dalvik`: Append the tag _"Dalvik"_ to the back of each file found in _C:\AndroidApplicationRE_ which has the `.smali` extension.

## Requirements
- Windows 10

## Download & Installation instructions
It is advised to setup a folder where you can just drop utilities in and execute globally (= Add a folder to your env variable/ PATH so everything inside it is globally accessible)

Latest stable: [HERE](https://github.com/mass1ve-err0r/rebrand/releases/latest)

## License
This is licensed under MIT.
