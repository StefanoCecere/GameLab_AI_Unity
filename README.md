# GameAI Lab
a collection of classic and ML AI examples  
Unity 2021.3 project  

## ML Agents
usiamo la release 20

- [Docs Ufficiali](https://github.com/Unity-Technologies/ml-agents/blob/release_20_docs/docs/Readme.md)
- [Spiegazione di tutti gli esempi](https://github.com/Unity-Technologies/ml-agents/blob/release_20_docs/docs/Learning-Environment-Examples.md)
- [Dettagli dei parametri config](https://unity-technologies.github.io/ml-agents/Training-Configuration-File/)

## Commands
Entrare con la Shell nella directory del progetto.

## Activate / Deactivate Python environment

```shell
source mlagents-env/bin/activate

## oppure se isntallato globalmente:
source ~/python-envs/mlagents-env/bin/activate

deactivate
```

## Run Training

```shell
mlagents-learn ml-config/my_config.yaml --run-id=my_id  
mlagents-learn ml-config/rollerball_config.yaml --run-id=RollerBall
mlagents-learn ml-config/ppo/3DBall.yaml --run-id=3DBall_Test
```

## Tensorboard

```shell
## meglio aprire una nuova shell parallela
tensorboard --logdir results

## oppure mandare in Background process
ctrl-Z  
bg / fg
```

## Installare ml-agents su Windows
procedure per installare Python (min 3.8.13, consigliata la 3.9.x) + ml-agents su Windows 64 bit  

[Docs Installazione](https://github.com/Unity-Technologies/ml-agents/blob/release_20_docs/docs/Installation.md)

Useremo un [Environment](https://github.com/Unity-Technologies/ml-agents/blob/release_17_docs/docs/Using-Virtual-Environment.md)

## Installare Python 3.9
scaricare l'ultima versione disponibile della 3.9 (ad oggi Python 3.9.13 - May 17, 2022) di **Windows installer (64-bit)** da <https://www.python.org/downloads/windows/>, durante l'installazione attivare il checkbox: ADD TO PATH

- eseguire "Prompt di comandi" as Administrator
- verificare che esista Python eseguendo il comando: `python`
- verificare che esista il comando `pip` esegundo il comando: `pip -V`, se non funziona provare con `pip3 -V`

## Installare ml-agents
Intalleremo tutto ciò che serve per il training in una directory del progetto, così che eliminato il progetto, non lasciamo centinaia di MB di files in giro.

NB: se `pip` non funziona, usare `pip3`

```shell
## entriamo nella directory del progetto Unity
cd C:/path/GameLab_AI_Unity/

## creaiamo environment Python
python -m venv mlagents-env
mlagents-env\Scripts\activate

## installiamo
pip install --upgrade pip
pip install --upgrade setuptools
pip install torch~=1.7.1 -f https://download.pytorch.org/whl/torch_stable.html
pip install mlagents==0.30.0

## testare installazione con
mlagents-learn --help
```