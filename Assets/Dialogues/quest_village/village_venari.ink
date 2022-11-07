INCLUDE village_globals.ink

->village_venari_main

=== village_venari_main
{quest_active == "village_villager":
    {not talked_venari:
        -> village_villager_venari_init.start
    - else:
        -> village_villager_venari_loop.start
    }
- else:
    -> village_default_venari.start
}

=== village_default_venari
= start
Hmm.#speaker:venari #portrait:venari_default #layout:character
-> eol

=== village_villager_venari_init
= start
~ talked_venari = true
~ village_villager_talked++
Hmm, from Polta aren't you?#speaker:venari #portrait:venari_frown #layout:character
I'm Venari. A hunter.#speaker:venari #portrait:venari_default
-> eol

=== village_villager_venari_loop
= start
Stay safe.#speaker:venari #portrait:venari_default #layout:character
-> eol