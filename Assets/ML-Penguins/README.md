# ML-Agents: Penguins - release 2 compatible

Like lot's of Unity Learn readers, we were trying [this tutorial]((https://learn.unity.com/project/ml-agents-penguins)) using the latest ML Agents, release 2, and it's changed too much.
In order to help, I've created this public repository which is an ML-Agents Release 2 (May 20, 2020) compatible upgrade of the Unity Learn [ML-Agents Penguins Tutorial](https://learn.unity.com/project/ml-agents-penguins).

This work is an help to upgrade the `ML-Agents: Penguins` tutorials to [ML-Agents Release 2](https://github.com/Unity-Technologies/ml-agents/tree/release_2).

| **Version** | **Release Date** | **Source** | **Documentation** | **Download** |
|:-------:|:------:|:-------------:|:-------:|:------------:|
| **Release 2** | **May 20, 2020** | **[source](https://github.com/Unity-Technologies/ml-agents/tree/release_2)** | **[docs](https://github.com/Unity-Technologies/ml-agents/tree/release_2/docs/Readme.md)** | **[download](https://github.com/Unity-Technologies/ml-agents/archive/release_2.zip)** |

# Addition
The `./Assets/ml-agents-realease1/` folder include the modified ml-agents config files for the training. The full train command is :

    mlagents-learn ./config/trainer_config.yaml --curriculum .\config\curricula\penguin.yaml --run-id penguin_01

# Licence & Credits
* `ML-Agents: Penguins` tutorials is a work of :
[Immersive Limit LLC](www.immersivelimit.com), see 
[Unity Connect reference](https://connect.unity.com/u/immersive-limit-llc).
The tutorial is hosted on the [Unity learn plateform](https://learn.unity.com/project/ml-agents-penguins), and is licensed to Unity and/or [Immersive Limit LLC](www.immersivelimit.com).
* [ml-agents release 2](https://github.com/Unity-Technologies/ml-agents/tree/release_2_docs/docs/) is licensed under the Apache 2.0.
* Thanks to [David Garner](https://connect.unity.com/u/david-garner) for his comments in the Unity Learn tutorial.
* upgrade by [SuperPoney](https://github.com/SP-SuperPoney/ML-Agents-Penguins)

*If you are a legal owner of the material available in this repository and do not want this work to be publicy avaliable, please contact me, or create an issue in this repository. I'll remove it ASAP.*
