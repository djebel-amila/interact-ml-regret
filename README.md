### The Re Min: Regression Example for InteractML in Unity

** WORK IN PROGRESS - NOT FUNCTIONAL at the moment **

[InteractML](http://interactml.com/) is the latest addition to the family of interactive machine learning toolkits by Dr. Rebecca Fiebrink. Tools like [Wekinator](http://www.wekinator.org/), [Sound Control](http://soundcontrolsoftware.com/) and [mimic](https://mimicproject.com) are being used by artists, educators and researchers to record and process various kinds of realtime data in order to generate sounds, visuals and other stuff. 

To learn more about this approach to machine learning you can visit two online courses, [Machine Learning for Musicians and Artists](https://www.kadenze.com/courses/machine-learning-for-musicians-and-artists/info) and [Apply Creative Machine Learning](https://www.futurelearn.com/courses/apply-creative-machine-learning). Highly recommended.

One of the strengths of Wekinator is that it can be connected to almost everything through a protocol called OSC. For example, 2 years ago I wrote a helper for the [Bitalino revolution Biodata sensor](https://bitalino.com/en/) that connects [Bitalino to Wekinator via a Processing sketch](https://github.com/i3games/p5_bitalino_helper), among others. The system could learn patterns from heart rate or skin conductance measures and Processing or send it to interactive such as Pure Data, Max or TouchDesigner. 

Now surely some people would like to make similar things in [Unity](https://unity.com/). Enter [InteractML](https://github.com/Interactml/iml-unity) which is built on a C++ machine learning library called [RapidLib](https://github.com/mzed/ofxRapidLib). InteractML uses the same approach as Wekinator and it works with Unity game objects. 

### Regression  

In this repo I share an example that measures the position of a game object and adapts sound parameters in a spooky way, not unlike a [Theremin](https://en.wikipedia.org/wiki/Theremin). This is an example for regression.

![Regression Graph](/Assets/Docs/InteractMLGraph.png)

InteractML comes with a [Wiki](https://github.com/Interactml/iml-unity/wiki) that explains the individual steps to get the system up and running and how to use it in detail. I am referencing it below. 

#### To set up the system (InteractML Wiki Step 1-5)

1. Install dependencies 
2. Build the regression pipeline. 
3. Check if the data flows into the `Teach the Machine Node` as expected.

#### To connect the system with Game Objects (InteractML Wiki Step 7, optional: 8)

1. Add Game Objects with Scripts to get the result of the regression.
2. Optional: Add Scripts to pipe data into the pipeline.

#### To record training examples (InteractML Wiki Step 5)

Uncheck `Run Model on Play` in the `Machine Learning System` node if it is checked.

<pre>
For each output value to be produced (I am using 0.0 and 1.0):     
    Set the value in the `Live Float Data` node     
    Start the game in Unity    
    For each example recoding:   
        Put the object in the appropriate position (I am using down for 0.0 and up for 1.0)     
        Press SPACE to start recording    
        Press SPACE to stop recording     
    Stop the game in Unity    
</pre>

The reason that you want to begin the movement before starting the recording is to avoid the model to pick up common features like an idle object at the beginning.

#### To train the model (InteractML Wiki Step 6)

1. Make sure the game is not running.
2. Klick on `Training`.
3. Wait a bit until it comes back and indicates that the model has been trained.

#### To run the model (InteractML Wiki Step 6)

1. Start the game in Unity.    
2. Press "P" to run the model. You can skip this step if you check `Run Model on Play` in the `Machine Learning System` node. 

### Compatibility

InteractML is in pre-release alpha, under heavy construction and not ready for production at the moment. It is for the curious who want to try out and experiment with interactive machine learning. The developers strongly recommend to use [release 0.20.4](https://github.com/Interactml/iml-unity/releases/tag/0.20.4) with **Unity 2019.2**. For this repo, I have used this setup on a Mac with the Github for Unity plugin.
