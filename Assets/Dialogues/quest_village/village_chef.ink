INCLUDE village_globals.ink

->village_chef_main

=== village_chef_main

{quest_active == "village_villager":
    {not talked_chef:
        -> village_villager_chef_init.start
    - else:
        -> village_villager_chef_loop.start
    }
- else:
    -> village_default_chef.start
}

=== village_default_chef
= start
...#speaker:chef #portrait:chef_default #layout:character
-> eol

=== village_villager_chef_init
= start
~ talked_chef = true
~ village_villager_talked++
I cook.#speaker:chef #portrait:chef_default #layout:character
-> eol

=== village_villager_chef_loop
= start
Hungry?#speaker:chef #portrait:chef_default #layout:character
-> eol
