INCLUDE village_globals.ink

->village_guri_main

=== village_guri_main

{
- not state_village_villager_init:
    -> village_default_guri.start
- quest_active == "village_villager":
    {not state_village_villager_guri:
        -> village_villager_guri_init.start
    - else:
        -> village_default_guri_loop.start
    }
- quest_active == "village_leave":
    {
    - not state_village_leave_guri:
        -> village_leave_guri_init.start
    - else:
        -> village_leave_guri_init.loop
    }
- state_village_villager_all:
    -> village_default_guri_loop.start
}

=== village_default_guri
= start
You tried to initiate conversation, but received no response.#layout:item
It felt awkward.#layout:item
~ talked("guri")
-> eol

=== village_default_guri_loop
= start
{talked_loop_guri:
- 0:
    ~ talked_loop_guri++
    He prepares the veggies.#layout:item
- 1:
    ~ talked_loop_guri++
    He cut the veggies.#layout:item
- 2:
    ~ talked_loop_guri++
    He cooks the veggies.#layout:item
- 3:
    ~ talked_loop_guri++
    He serves the veggies.#layout:item
- 4:
    ~ talked_loop_guri = 0
    He feels relieved.#layout:item
    ~ talked("guri")
}

-> eol

=== village_villager_guri_init
= start
...#speaker:guri #portrait:guri_default #layout:character
(I'll just put the bread on the counter..)#speaker:ragi #portrait:ragi_default
* [(Put Coco's bread.)]
He nodded.#layout:item

~ doneQuest("village_villager_guri")
~ talked_loop_guri = 0
-> eol

=== village_leave_guri_init
= start
You tried to initiate conversation.#layout:item
...#layout:item
He gives you a package.#layout:item
It's a bento.#layout:item
He smiles at you.#layout:item
Thanks.#speaker:ragi #portrait:ragi_default #layout:character
~ doneQuest("village_leave_guri")
-> eol

= loop
He waves at you.#layout:item
~ talked("guri")
-> eol