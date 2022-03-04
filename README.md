# GameAI Lab 
Unity 2021 project
a collection of AI examples

## ML Agents
usiamo la release 17

### docs
https://github.com/Unity-Technologies/ml-agents/tree/release_17_docs/docs

Spiegazione di tutti gli esempi:  
https://github.com/Unity-Technologies/ml-agents/blob/release_17_docs/docs/Learning-Environment-Examples.md

#### Commands
go into project directory

```
## activate Python environment
source ~/python-envs/mlagents-env/bin/activate

## deactivate Python environment
deactivate

## Run Training
mlagents-learn config/my_config.yaml --run-id=my_id  
mlagents-learn config/rollerball_config.yaml --run-id=RollerBall
mlagents-learn config/ppo/3DBall.yaml  --run-id=3DBall_1

## Tensorboard
tensorboard --logdir results --port 6006
```
#### background process
ctrl-Z  
bg / fg

## installare ml-agents
procedure per installare Python (min 3.6.1) + ml-agents su Windows 64 bit  
<https://github.com/Unity-Technologies/ml-agents/blob/release_17_docs/docs/Installation.md>

### Create Python environment

```
python3 -m venv ~/python-envs/mlagents-env
source ~/python-envs/mlagents-env/bin/activate
pip install --upgrade pip
pip install --upgrade setuptools
pip install torch~=1.7.1 -f https://download.pytorch.org/whl/torch_stable.html
pip install mlagents==0.26.0
```

### metodo 1: diretto (più veloce)
scaricare Windows x86-64 executable installer da https://www.python.org/downloads/windows/, durante l'installazione attivare il checkbox: ADD TO PATH

- eseguire "prompt ti comandi" as Administrator
- verificare che esista Python eseguendo il comando: `python`
- verificare che esista il comando pip esegundo il comando: `pip -V`, se non funziona provare con `pip3 -V`

```
pip install --upgrade pip
pip install --upgrade setuptools
pip install torch~=1.7.1 -f https://download.pytorch.org/whl/torch_stable.html
pip install mlagents==0.26.0
```
entrare nella directory del progetto ml-agents: 
`cd C:/blabla bla/ml-agents/`

provare a lanciare il comando `mlagents-learn`, deve comparire il logo UNITY

### metodo 2: con virtual environments (consigliato)
se volete isolare le installazioni di Python e relativi moduli, ad esempio per avere diverse versioni separate, si usano i virtual Environments, ovvero delle directory con dentro tutta la config.

L'installazione e configurazione è spiegata qui:
<https://github.com/Unity-Technologies/ml-agents/blob/release_17_docs/docs/Using-Virtual-Environment.md>
