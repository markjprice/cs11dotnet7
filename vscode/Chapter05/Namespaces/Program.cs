using France;
using us = Texas; // us becomes alias for the namespace and it is not imported
using Env = System.Environment;

Paris p1 = new();
us.Paris p2 = new();

WriteLine(Env.OSVersion);
WriteLine(Env.MachineName);
WriteLine(Env.CurrentDirectory);