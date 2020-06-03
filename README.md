# GameAI Lab
Unity project

a collection of AI examples

## ML Agents

### docs
https://github.com/Unity-Technologies/ml-agents/blob/release_2_branch/docs/Getting-Started.md

virtual environments:
https://github.com/Unity-Technologies/ml-agents/blob/release_2_branch/docs/Using-Virtual-Environment.md

### commands
#### activate environment
source ~/python-envs/ml-agents/bin/activate

#### run the simulation
go into project directory

`mlagents-learn config/my_config.yaml --run-id=my_id`  
`mlagents-learn config/rollerball_config.yaml --run-id=RollerBall`

#### background process
ctrl-Z
bg / fg

#### log board
`tensorboard --logdir=summaries --port=6006`

#### deactivate environment
`source ~/python-envs/sample-env/bin/deactivate`
