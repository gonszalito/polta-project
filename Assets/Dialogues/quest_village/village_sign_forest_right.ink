INCLUDE village_globals.ink

-> sign_forest_right_main

=== sign_forest_right_main
{
- not state_village_leave_all:
    -> init
- state_village_leave_all:
    -> quit
- else:
    -> init
}


= init
"FOREST"#layout:item
-> DONE

= quit
(I should go to the forest now.) #speaker:ragi #portrait:ragi_default #layout:character
-> DONE