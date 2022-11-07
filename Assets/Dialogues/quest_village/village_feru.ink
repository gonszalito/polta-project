INCLUDE village_globals.ink

->village_feru_main

=== village_feru_main

{quest_active == "village_villager":
    {not talked_feru:
        -> village_villager_feru_init.start
    - else:
        -> village_villager_feru_loop.start
    }
- else:
    -> village_default_feru.start
}

=== village_default_feru
= start
Ohoho.#speaker:feru #portrait:feru_happy #layout:character
-> eol

=== village_villager_feru_init
= start
~ talked_feru = true
~ village_villager_talked++
Ohoho, young man.#speaker:feru #portrait:feru_happy #layout:character
Good to see you. I'm Feru.#speaker:feru #portrait:feru_default
I take care of the village cats.#speaker:feru #portrait:feru_default
-> eol

=== village_villager_feru_loop
= start
A pleasure to meet you.#speaker:feru #portrait:feru_default #layout:character
-> eol


