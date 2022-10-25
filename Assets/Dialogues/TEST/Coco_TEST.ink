INCLUDE globals.ink
#layout:character
{ quest_acorn_accept == false : -> acorn_start | -> acorn_request }

-> acorn_start

=== acorn_start===
I need some ingredients to make the next batch of bread  #speaker:Coco #portrait:coco_sad #layout:character
Do you mind helping me get some?
* [Sure]
    Great! there should be some <b><color=\#F8FF30>Acorn</color></b> lying around here #speaker:Coco #portrait:coco_default
    ~ quest_acorn_accept = true
    -> DONE 
* [Nah I'll pass]
    Aww that's too bad ;( #speaker:Coco #portrait:coco_sad
    -> DONE

=== acorn_request ===

{ acorn == false : -> acorn_repeat | -> acorn_found }

=== acorn_repeat ===
If only I had a piece of acorn....  #speaker:Coco #portrait:coco_sad #layout:character
-> END

=== acorn_found ===
Wow you've found it! #speaker:Coco #portrait:coco_default #layout:character
-> END
