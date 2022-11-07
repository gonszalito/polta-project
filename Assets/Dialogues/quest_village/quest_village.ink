// INCLUDE village_globals.ink

// INCLUDE village_coco.ink
// INCLUDE village_feru.ink
// INCLUDE village_aru.ink
// INCLUDE village_chef.ink
// INCLUDE village_venari.ink

// INCLUDE village_object_flour.ink
// INCLUDE village_object_bread.ink
// INCLUDE village_object_eldertree.ink


// ~queueQuest("village_intro")
// -> main

// === main
// [!] {quest_giver}
// + [Coco]
//     -> village_coco_main
// + [Feru]
//     -> village_feru_main
// + [Chef]
//     -> village_chef_main
// + [Aru]
//     -> village_aru_main
// + [Venari]
//     -> village_venari_main
// + [Objects]
//     + + [Flour]
//         -> village_object_flour_main
//     + + [Bread]
//         -> village_object_bread_main
//     + + [Tree]
//         -> village_object_eldertree_main
