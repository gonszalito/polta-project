INCLUDE village_villager_coco.ink
INCLUDE village_villager_feru.ink
INCLUDE village_villager_chef.ink
INCLUDE village_villager_aru.ink
INCLUDE village_villager_venari.ink

VAR talked_feru = false
VAR talked_chef = false
VAR talked_aru = false
VAR talked_venari = false
VAR total = 0

/*
[villager] Villager quest
-> coco.coco_init
-> feru.feru_init
-> chef.chef_init
-> aru.aru_init
-> venari.venari_init
*/


-> coco_init.start

=== main ===
// walk
Talk to:
    + [Coco]
        ~ total = talked_feru + talked_chef + talked_aru + talked_venari
        // Coco
        {total < 4:
            -> coco_false
        - else:
            -> coco_true
        } 
    + [Feru]
        // Feru
        {talked_feru == false:
            -> feru_init
        - else:
            -> feru_repeat
        }
    + [Chef]
        // Chef
        {talked_chef == false:
            -> chef_init
        - else:
            -> chef_repeat
        }
    + [Aru]
        // Aru
        {talked_aru == false:
            -> aru_init
        - else:
            -> aru_repeat
        }
    + [Venari]
        // Venari
        {talked_venari == false:
            -> venari_init
        - else:
            -> venari_repeat
        }
-> main