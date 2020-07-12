### The Re Min: Regression Example for InteractML in Unity

[InteractML](http://interactml.com/) ist the spiritual successor of [Wekinator](http://www.wekinator.org/), Rebecca Fiebrink's toolkit for interactive Machine Learning. Wekinator is based on the [WEKA toolkit](https://www.cs.waikato.ac.nz/ml/weka/) and it has been used by artists and researchers to record and process various kinds of realtime data in order to generate sounds, visuals and other stuff. 

There is even an online course "Machine Learning for Musicians and Artists" by the creator of Wekinator herself: https://www.kadenze.com/courses/machine-learning-for-musicians-and-artists/info. Highly recommended.

One of the strengths of Wekinator is that it can be connected to almost everything through OSC. For example, 2 years ago I wrote a helper for the [Bitalino revolution Biodata sensor](https://bitalino.com/en/) that connects [Bitalino to Wekinator via a Processing sketch](https://github.com/i3games/p5_bitalino_helper), among others. The system could learn patterns from heart rate or skin conductance measures and send it to, say, pure data or Max MSP. 

Now surely some people would like to make interesting stuff like that, but in [Unity](https://unity.com/). Enter InteractML.

InteractML comes with a [wiki](https://github.com/Interactml/iml-unity/wiki) that explains in detail the individual steps to get the system up and running. 

### Regression  

In this repo I share an example that measures the position of a game object and adapts sound parameters in a spooky way, not unlike a [Theremin](https://en.wikipedia.org/wiki/Theremin). This is an example for regression.

![Classification Graph](/Assets/Docs/InteractMLGraph.png)

#### To set up the system
1. Install dependencies (Step 1)
2. Build the classification pipeline (InteractML Wiki Step 1-5)
3. Check if the data flows into the `Teach the Machine Node` as expected

#### To record training examples (InteractML Wiki Step 5):
<pre>
For each output value to be produced (I am using 0.0 and 1.0 as the two extreme values):     
    Set the value in the `Live Float Data` node.     
    Start the game in Unity    
    For each example recoding:     
        Press SPACE to record    
        Put the object in the appropriate position (I am using down for 0.0 and up for 1.0)      
        Press SPACE to stop recording     
    Stop the game in Unity    
</pre>

#### To train the model (InteractML Wiki Step 6):
1. If it is running, stop the game in Unity 
2. Klick on `Training`
3. Wait a bit 

#### To run the model (InteractML Wiki Step 6):
1. Start the game in Unity    
2. Press "P" to run the model    

### Compatibility
InteractML is in pre-release alpha and under heavy construction at the moment. See https://github.com/Interactml/iml-unity. The developers strongly recommend to use Unity 2019.2 with [release 0.20.2](https://github.com/Interactml/iml-unity/releases/tag/0.20.2). For this repo, I am using this setup on a Mac.
