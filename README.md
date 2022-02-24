# GameAI Lab
Unity 2021 project
a collection of AI examples

## ML Agents

### docs
https://github.com/Unity-Technologies/ml-agents/tree/release_17_docs/docs

virtual environments: https://github.com/Unity-Technologies/ml-agents/blob/release_17_docs/docs/Using-Virtual-Environment.md

### commands
#### activate / deactivate environment
source ~/python-envs/mlagents-env/bin/activate
deactivate

#### run the simulation
go into project directory

`mlagents-learn config/my_config.yaml --run-id=my_id`  
`mlagents-learn config/rollerball_config.yaml --run-id=RollerBall`

#### background process
ctrl-Z
bg / fg

#### log board
`tensorboard --logdir=summaries --port=6006`

#### create environmnet
python3 -m venv ~/python-envs/mlagents-env
source ~/python-envs/mlagents-env/bin/activate
pip install --upgrade pip
pip install --upgrade setuptools
pip install torch~=1.10 -f https://download.pytorch.org/whl/torch_stable.html
pip install mlagents==0.26.0

## installare ml-agents
procedure per installare Python + ml-agents su Windows 64 bit

useremo la versione Verified Package 1.0.6.
docs ufficiali: <https://github.com/Unity-Technologies/ml-agents/blob/release_2_verified_docs/docs/Readme.md>

## metodo 1: diretto (più veloce)
scaricare Windows x86-64 executable installer da https://www.python.org/downloads/windows/ ,durante l'installazione attivare il checkbox: ADD TO PATH

eseguire "prompt ti comandi" as Administrator
verificare che esista Python eseguendo il comando: `python`
verificare che esista il comando pip esegundo il comando: `pip -V`

```
pip install --upgrade pip
pip3 install mlagents==0.16.1
```

entrare nella directory del progetto ml-agents: 
`cd C:/blabla bla/ml-agents/`

provare a lanciare il comando `mlagents-learn`

deve comparire il logo UNITY

## metodo 2: con virtual environments (consigliato)
se volete compartimentare le installazioni di Python e relativi moduli, ad esempio per avere diverse versioni separate, si usano i virtual Environments, ovvero delle directory con dentro tutta la config.

L'installazione e configurazione è spiegata qui:
<https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Using-Virtual-Environment.md>


## metodo 3: via Anaconda
se non dovesse funzionare il metodo 1, o non avete dimestichezza con la Shell e comandi, c'è la possibilità di usare Anaconda che è un ambiente di gestione pacchetti Python, e che usavamo fino all'anno scorso. poi non so perché l'hanno deprecato, ma è tutt'ora funzionate.
le istruzioni molto dettagliate sono qui: 
https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Installation-Anaconda-Windows.md

