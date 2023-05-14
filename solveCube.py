import json
import kociemba
import sys

cubeStateFileName = sys.argv[1]
cubeSolutionFileName = sys.argv[2]

fileCubeState = open(cubeStateFileName, "r")
cubeStateJson = fileCubeState.read()
fileCubeState.close()   

cubeState = json.loads(cubeStateJson)
cubeStateString = cubeState["cubeStateString"]

solution = kociemba.solve(cubeStateString)

fileCubeSolution = open(cubeSolutionFileName, "w")
fileCubeSolution.write(solution)
fileCubeSolution.close()