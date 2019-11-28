A l'intention du service technique DPD, liste des problèmes/interrogations liés à l'intégration :

1. 

Gestion d'erreur: Rien ne permet au moment de parser une réponse json du serveur de savoir si c'est une erreur ou la réponse attendue. 
Ce n'est qu'en essayant de parser la réponse, et que l'opération échoue, qu'on peut se rendre compte que l'objet transmit était en fait un message d'erreur.

Cause probable: Le cas de la "déserialization" directement dans des objets fortement typés n'est pas prévue dans le design.
Résolution possible: Rajouter une info dans le header de la réponse qui signifie au client qu'il s'agit d'une erreur. 
							exemple: JSON-Content-Type: Error; Ou bien encore renvoyer un code réponse 500:Erreur au lieu de renvoyer un 200:OK

2. 

La fonction 4.2.1: Cancel a Collection Request / Input parameters ne retourne jamais et provoque un timeout du proxy. (code 504)
(voir test dans le projet)

3. (problème mineur)

La documentation appelle "List" tout ce qui est sous objet, qu'il s'agisse d'un array (List) [...] ou d'un object (Struct) {...}, ce qui rends impossible d'implémenter
le protocole en se basant uniquement sur la documentation.

4. (problème mineur)

Certain champs facultatifs dans la doc sont en fait exigés par l'API.


Cordialement,