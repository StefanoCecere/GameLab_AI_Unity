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

`mlagents-learn config-ml/my_config.yaml --run-id=my_id`  
`mlagents-learn config-ml/rollerball_config.yaml --run-id=RollerBall`

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

