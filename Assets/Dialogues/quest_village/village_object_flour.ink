INCLUDE village_globals.ink

->village_object_flour_main

=== village_object_flour_main
{
- quest_active == "village_bread" && not village_bread_obtained:
    -> village_bread_object_flour.start
- else:
    -> village_default_object_flour.start
}


=== village_bread_object_flour
= start
~ village_bread_obtained = true
Obtained flour!#layout:item
-> eol

=== village_default_object_flour
= start
Flour for bakery.#layout:item
-> eol
