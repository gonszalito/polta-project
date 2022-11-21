INCLUDE ../globals.ink
/*
Sequences:
1. village_intro
2. village_bread
3. village_villager
4. village_chat
5. village_leave

Sides:
1. village_chat_feru
2. village_chat_venari
3. village_chat_aru
*/

// a

=== function refreshtalk
~ talked_coco = false
~ talked_feru = false
~ talked_venari = false
~ talked_aru = false
~ talked_guri = false
~ talked_boni = false

=== function refreshQuestGiverNPC
~ quest_giver_coco = false
~ quest_giver_feru = false
~ quest_giver_aru = false
~ quest_giver_venari = false
~ quest_giver_guri = false
~ quest_giver_boni = false
~ quest_giver_object_flour = false
~ quest_giver_trigger_quit = false

=== function talked(name)
{name:
- "coco":
    ~ talked_coco = true
    ~ quest_giver_coco = false
- "aru":
    ~ talked_aru = true
    ~ quest_giver_aru = false
- "venari":
    ~ talked_venari = true
    ~ quest_giver_venari = false
- "feru":
    ~ talked_feru = true
    ~ quest_giver_feru = false
- "guri":
    ~ talked_guri = true
    ~ quest_giver_guri = false
- "boni":
    ~ talked_boni = true
    ~ quest_giver_boni = false
}

=== function untalk(name)
{name:
- "coco":
    ~ talked_coco = false
- "aru":
    ~ talked_aru = false
- "venari":
    ~ talked_venari = false
- "feru":
    ~ talked_feru = false
- "guri":
    ~ talked_guri = false
- "boni":
    ~ talked_boni = false
}

=== function queueQuest(quest_name)
~ refreshQuestGiverNPC()
{quest_name:
- "village_intro":
    ~ quest_giver_coco = true
    
- "village_bread_init":
    ~ quest_giver_coco = true

- "village_bread_flour":
    ~ quest_giver_object_flour = true

- "village_bread_return":
    ~ quest_giver_coco = true
    
- "village_villager_init":
    ~ quest_giver_coco = true
    
- "village_villager_all":
    ~ refreshtalk()
    ~ quest_giver_feru = true
    ~ quest_giver_aru = true
    ~ quest_giver_venari = true
    ~ quest_giver_guri = true
    ~ quest_giver_boni = true

- "village_villager_return":
    ~ quest_giver_coco = true
    
- "village_chat_all":
    ~ untalk("coco")
    ~ untalk("feru")
    ~ untalk("aru")
    ~ untalk("venari")
    ~ quest_giver_coco = true
    ~ quest_giver_feru = true
    ~ quest_giver_aru = true
    ~ quest_giver_venari = true

- "village_chat_return":
    ~ quest_giver_venari = true

- "village_leave_init":
    ~ quest_giver_feru = true

- "village_leave_all":
    ~ refreshtalk()
    ~ quest_giver_coco = true
    ~ quest_giver_aru = true
    ~ quest_giver_venari = true
    ~ quest_giver_guri = true
    ~ quest_giver_boni = true
    
- "village_leave_quit":
    ~ quest_giver_trigger_quit = true
    ~ quest_giver_sign_forest_right = true
    ~ quest_giver_sign_forest_left = true
}

=== function doneQuest(quest_name)
{quest_name:

- "sign_village_right":
    ~ quest_giver_sign_village_right = false

- "village_intro":
    ~ state_village_intro = true
    ~ queueQuest("village_bread_init")
    
- "village_bread_init":
    ~ state_village_bread_init = true
    ~ queueQuest("village_bread_flour")
    
- "village_bread_flour":
    ~ state_village_bread_flour = true
    ~ queueQuest("village_bread_return")

- "village_bread_return":
    ~ state_village_bread_return = true
    ~ queueQuest("village_villager_init")
    
- "village_villager_init":
    ~ village_villager_talked++
    ~ state_village_villager_init = true
    ~ queueQuest("village_villager_all")

- "village_villager_feru":
    ~ village_villager_talked++
    ~ state_village_villager_feru = true
    ~ quest_giver_feru = false
    ~ doneQuest("village_villager_all")

- "village_villager_aru":
    ~ village_villager_talked++
    ~ state_village_villager_aru = true
    ~ quest_giver_aru = false
    ~ doneQuest("village_villager_all")

- "village_villager_venari":
    ~ village_villager_talked++
    ~ state_village_villager_venari = true
    ~ quest_giver_venari = false
    ~ doneQuest("village_villager_all")

- "village_villager_guri":
    ~ village_villager_talked++
    ~ state_village_villager_guri = true
    ~ quest_giver_guri = false
    ~ doneQuest("village_villager_all")

- "village_villager_boni":
    ~ village_villager_talked++
    ~ state_village_villager_boni = true
    ~ quest_giver_boni = false
    ~ doneQuest("village_villager_all")

- "village_villager_all":
    {village_villager_talked == amount_npc:
        ~ state_village_villager_all = true
        ~ queueQuest("village_villager_return")
    }

- "village_villager_return":
    ~ state_village_villager_return = true
    ~ quest_active = ""
    ~ queueQuest("village_chat_all")

- "village_chat_coco":
    ~ state_village_chat_coco = true
    ~ quest_giver_coco = false
    ~ doneQuest("village_chat_all")

- "village_chat_feru":
    ~ state_village_chat_feru = true
    ~ quest_giver_feru = false
    ~ doneQuest("village_chat_all")

- "village_chat_aru":
    ~ state_village_chat_aru = true
    ~ quest_giver_aru = false
    ~ doneQuest("village_chat_all")

- "village_chat_venari":
    ~ state_village_chat_venari = true
    ~ quest_giver_venari = false
    ~ doneQuest("village_chat_all")

- "village_chat_all":
    {state_village_chat_coco && state_village_chat_feru && state_village_chat_venari && state_village_chat_aru:
        ~ state_village_chat_all = true
        ~ queueQuest("village_chat_return")
    }

- "village_chat_return":
    ~ state_village_chat_return = true
    ~ queueQuest("village_leave_init")

- "village_leave_init":
    ~ state_village_leave_init = true
    ~ village_leave_talked++
    ~ queueQuest("village_leave_all")

- "village_leave_coco":
    ~ state_village_leave_coco = true
    ~ village_leave_talked++
    ~ quest_giver_coco = false
    ~ doneQuest("village_leave_all")


- "village_leave_aru":
    ~ state_village_leave_aru = true
    ~ village_leave_talked++
    ~ quest_giver_aru = false
    ~ doneQuest("village_leave_all")

- "village_leave_guri":
    ~ state_village_leave_guri = true
    ~ village_leave_talked++
    ~ quest_giver_guri = false
    ~ doneQuest("village_leave_all")

- "village_leave_venari":
    ~ state_village_leave_venari = true
    ~ village_leave_talked++
    ~ quest_giver_venari = false
    ~ doneQuest("village_leave_all")

- "village_leave_boni":
    ~ state_village_leave_boni = true
    ~ village_leave_talked++
    ~ quest_giver_boni = false
    ~ doneQuest("village_leave_all")

- "village_leave_all":
    {village_leave_talked == amount_npc:
        ~ state_village_leave_all = true
        ~ queueQuest("village_leave_quit")
    }
    
- "village_leave_quit":
    ~ state_village_leave_quit = true
    ~ refreshQuestGiverNPC()
}


=== function printQuestGiver
{quest_giver_coco: [!] Coco}
{not quest_giver_coco && not talked_coco: [...] Coco}
{quest_giver_feru: [!] Feru}
{not quest_giver_feru && not talked_feru: [...] Feru}
{quest_giver_guri: [!] Guri}
{not quest_giver_guri && not talked_guri: [...] Guri}
{quest_giver_aru: [!] Aru}
{not quest_giver_aru && not talked_aru: [...] Aru}
{quest_giver_venari: [!] Venari}
{not quest_giver_venari && not talked_venari: [...] Venari}

{quest_giver_object_flour: [!] Flour}
{quest_giver_trigger_quit: [!] Quit}




=== eol
-> DONE
