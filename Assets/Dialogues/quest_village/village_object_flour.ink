INCLUDE village_globals.ink

->village_object_flour_main

=== village_object_flour_main
{
- quest_active == "village_bread" && state_village_bread_init:
    {
    - not state_village_bread_flour:
        -> village_bread_object_flour.start
    - else:
        -> village_bread_object_flour.loop
    }
    
- else:
    {ending_cheat >= 8: 
        ~ state_village_leave_all = true
    }
    -> village_default_object_flour.start
}


=== village_bread_object_flour
= start
You have obtained flour!#layout:item
~ doneQuest("village_bread_flour")
-> eol

= loop
Flour for bakery.#layout:item
-> eol

=== village_default_object_flour
= start
Flour for bakery.#layout:item
~ ending_cheat++
-> eol
