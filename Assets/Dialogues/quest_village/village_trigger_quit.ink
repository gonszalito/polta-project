INCLUDE village_globals.ink

->village_trigger_quit_main

=== village_trigger_quit_main
{not state_village_leave_all:
    -> village_default_trigger_quit.start
- else:
    -> village_leave_trigger_quit.start
}



=== village_default_trigger_quit
= start
You can't leave the village yet!#layout:item
-> eol

=== village_leave_trigger_quit
= start
You left the village.#layout:item
Thank you for playing!#layout:item
~ doneQuest("village_leave_quit")
-> eol