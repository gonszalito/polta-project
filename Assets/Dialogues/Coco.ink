INCLUDE globals.ink
VAR talked = false
-> start

=== start ===
I need some ingredients to make the next batch of bread  #speaker:Coco #portrait:Coco_sad
Do you mind helping me get some?
Great! there should be some lying around here #speaker:Coco #portrait:Coco_happy
-> acorn_request

=== acorn_request ===

{ acorn == false : -> acorn_repeat | -> acorn_found }

=== acorn_repeat ===
If only I had a piece of acorn.... 
-> END

=== acorn_found ===
Wow you've found it!
-> END
