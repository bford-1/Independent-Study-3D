# -*- coding: utf-8 -*-
"""
Created on Thu Apr  4 13:33:05 2024

@author: fordb
"""

import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
import mesa
from mesa import Agent, Model, batch_run
from mesa.time import RandomActivation
from mesa.space import SingleGrid
class SIRagent(mesa.Agent):

    def __init__(self, unique_id, model):
        super().__init__(unique_id, model)
        self.state = "S"
        self.infected_time = 0
    def infection(self):
        if self.infected_time == 4:
            self.state = "R"
        else:
            self.infected_time += 1
    def infect_neighbour(self):
        
        neighbours = self.model.grid.get_neighbors(self.pos, moore=False)
        if self.state != "I": 
            pass
        elif len(neighbours) == 0:
            pass
        else:
            for n in neighbours:
                if n.state == "R":
                    pass
                elif n.state == "I":
                    pass
                else:
                    n.state == "I"
    def step(self):
        self.infection()
        m = False
        moves = self.model.grid.get_neighborhood(self.pos, moore=False)
        move = self.random.choice(moves)
        if self.model.grid.is_cell_empty(move) == True:
            self.model.grid.move_agent(self, move)
        self.infect_neighbour()
class SIRmodel(Model):
    def __init__(self, num_agents, dim):
        super().__init__()
        self.num_agents = num_agents
        self.dim = dim
        self.schedule = RandomActivation(self)
        self.grid = SingleGrid(dim, dim, torus=False)
        for i in range(self.num_agents):
            a = SIRagent(i, self)
            self.schedule.add(a)
            self.grid.move_to_empty(a)
        c = self.random.choice(self.schedule.agents)
        c.state = "I"
    def step(self):
        self.schedule.step()
        self.dis()
    def dis(self):
        cell = np.zeros((self.dim,self.dim))
        for c in self.schedule.agents:
            if c.state == "S":
                cell[c.pos[0], c.pos[1]] = 1
            elif c.state == "I":
                cell[c.pos[0], c.pos[1]] = 2
            else:
                cell[c.pos[0], c.pos[1]] = 3
        plt.clf()
        sns.heatmap(cell, cmap=['white', 'red', 'blue', 'green'], cbar=False, square=True)
        plt.pause(.1)
        plt.draw()

SIR = SIRmodel(30, 10)
for i in range(50):
    SIR.step()
      
            
        