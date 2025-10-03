# Name That Smell: Bloaters

(Created with GenAI/ChatGPT, February 2025)

Recognising code smells is pattern matching of elements of code. I want
to practice this and teach you the patterns, regardless of programming language.

## About Me

### Peter Kofler

* Ph.D. (Appl. Math.)
* Professional Software Developer
* "fanatic about code quality"
* Technical Agile Coach/Mentor

### I help development teams with

* Professionalism
* Quality and Productivity
* Continuous Improvement

### Mentoring

* Pair Programming
* Programming Workshops
* Deliberate Practice, e.g. Coding Dojos

### Motto

Developing Quality Software Developers

## Code Smell Theory

### data class

A class contains only fields and crude methods for accessing them (getters and setters).

```php
<?php

class Character {
    public string $name;
    public int $level;
    public int $health;

    public function __construct(string $name, int $level, int $health) {
        $this->name = $name;
        $this->level = $level;
        $this->health = $health;
    }
}

function isAlive(Character $character): bool {
    return $character->health > 0;
}
```

### data clump

Different parts of the code contain identical groups of variables (such as parameters or fields).

```go
package construction

type Building struct {
    name       string
    latitude   float64
    longitude  float64
    floors     int
    contractor string
}

func calculateBuildingValue(building Building) Money {
    baseValue := float64(building.floors) * 100000
    if building.contractor == "TopBuild Co." {
        baseValue *= 1.2
    }
    return Money{amount: baseValue, currency: "USD"}
}
```

### long parameter list

There are more than three or four parameters for a method.

```java
class PicassoArtwork {

    public double artisticValue(
        BrushSize brushSize, PaintColour paintColour,
        CanvasSize canvasSize, StrokeThickness strokeThickness,
        ArtisticSkill artisticSkill) {

        double value = brushSize.getValue() * 0.3 +
            canvasSize.getWidth() * canvasSize.getHeight() * 0.1 +
            strokeThickness.getThickness() * 0.2 +
            artisticSkill.getLevel() * 0.4;

        if (paintColour.isBlue()) {
            value *= 1.2;
        }

        return value;
    }
}
```

### primitive obsession

```javascript
class Crop {

    constructor(name, area, productionPerUnit) {
        this.name = name;
        this.yield = area * productionPerUnit;
    }

    // some logic omitted
}

function getHighestYield(crops) {
    return crops.reduce((max, crop) => {
        const yieldsMore = crop.yield > max.yield;
        return yieldsMore ? crop : max;
    });
}
```

## Quiz Time

(Spoilers omitted)

## Going Crazy - Trust Your Instinct

(Spoilers omitted)

## Questions?

* Peter Kofler
* codecopkofler
* <www.code-cop.org>

Thank you for coming to my session.
